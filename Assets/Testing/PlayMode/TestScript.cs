using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;

public class TestScript
{ 
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestPlayerExists()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        SceneManager.LoadScene("Tutorial");
        yield return null;
        GameObject player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestPlayerMoveToRight()
    {
        SceneManager.LoadScene("Tutorial");
        yield return null;
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 initialPosition = player.transform.position;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D));
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(player.transform.position.x, initialPosition.x);
    }

    [UnityTest]
    public IEnumerator TestPlayerMoveToLeft()
    {
        SceneManager.LoadScene("Tutorial");
        yield return null;
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 initialPosition = player.transform.position;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A));
        yield return new WaitForSeconds(0.1f);
        Assert.Less(player.transform.position.x, initialPosition.x);
    }

    [UnityTest]
    public IEnumerator TestPlayerJump()
    {
        SceneManager.LoadScene("Tutorial");
        yield return null;
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 initialPosition = player.transform.position;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(player.transform.position.y, initialPosition.y);
    }
}
