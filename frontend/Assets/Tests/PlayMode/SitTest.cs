using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SitTest
{
    [UnityTest]
    public IEnumerator SitDown()
    {
        var gameObject  = new GameObject();
        var cam = new GameObject();

        var player = gameObject.AddComponent<PlayerFPC>(); 
        var dummyCam = cam.AddComponent<Camera>();
        var cc = gameObject.AddComponent<CharacterController>();
        
        player.cam = dummyCam;
        
        player.sitting();
        
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(new Vector3(12.5f, 3, 10.1f), gameObject.transform.position);
    }
}
