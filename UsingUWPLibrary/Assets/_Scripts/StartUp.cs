using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_WSA && !UNITY_EDITOR
using Windows.Security.Credentials;
#endif
public class StartUp : MonoBehaviour
{
    string resource = "UsingUWPLibrary";
    string username = "sbovo";
    string password = "secret";

    // Use this for initialization
    void Start()
    {
#if UNITY_WSA && !UNITY_EDITOR
        UWP_PasswordVault_Helper.PasswordVaultHelper pvh = 
            new UWP_PasswordVault_Helper.PasswordVaultHelper();
        pvh.WritePasswordCredential(resource, username, password);
        StartCoroutine(Check());
#else
        FOVFeedback.instance.ModifyText(":-( This app does not work in the Editor");
#endif
    }

    private IEnumerator Check()
    {
        yield return new WaitForSeconds(5f);
#if UNITY_WSA && !UNITY_EDITOR
        UWP_PasswordVault_Helper.PasswordVaultHelper pvhCheck =
            new UWP_PasswordVault_Helper.PasswordVaultHelper();
        PasswordCredential pc = pvhCheck.GetPasswordCredential(resource, username);
        FOVFeedback.instance.ModifyText(pc.Password);
#endif
    }

    // Update is called once per frame
    void Update()
    {
    }
}
