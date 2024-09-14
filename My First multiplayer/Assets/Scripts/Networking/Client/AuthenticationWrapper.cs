using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.VisualScripting;
using UnityEngine;

public static class AuthenticationWrapper
{
    public static AuthStates AuthState {  get; private set; } = AuthStates.NotAuthenticated;

    public static async Task<AuthStates> DoAuth(int maxTries = 5)
    {
        if (AuthState == AuthStates.Authenticated) { return AuthState; }
        if (AuthState == AuthStates.Authenticating) 
        {
            Debug.Log("Already Authenticating");
            await Authenticating();
            return AuthState;
        }
        await SignInAnonymouslyAsync(maxTries);
        return AuthState;
    }

    private static async Task<AuthStates> Authenticating()
    {
        while (AuthState == AuthStates.Authenticating || AuthState == AuthStates.NotAuthenticated )
        {
            await Task.Delay(200);
        }
        return AuthState;
    }

    private static async Task SignInAnonymouslyAsync(int maxRetries)
    {
        AuthState = AuthStates.Authenticating;
        int tries = 0;
        while (AuthState == AuthStates.Authenticating && tries < maxRetries)
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                if (AuthenticationService.Instance.IsSignedIn && AuthenticationService.Instance.IsAuthorized)
                {
                    AuthState = AuthStates.Authenticated;
                    break;
                }
            }
            catch(AuthenticationException e)
            {
                Debug.LogError(e);
                AuthState = AuthStates.Error;
            }
            catch (RequestFailedException e)
            {
                Debug.LogError(e);
                AuthState = AuthStates.Error;
            }
           
            tries++;
            await Task.Delay(1000);
        }
        if (AuthState != AuthStates.Authenticated)
        {
            Debug.LogError($"time out in {tries} numbers of tries.");
            AuthState = AuthStates.TimeOut;
        }
    }
}

public enum AuthStates
{
    NotAuthenticated,
    Authenticating,
    Authenticated,
    Error,
    TimeOut
}
