using System;
using System.Collections;
using UnityEngine;

public static class CoroutineHelper
{
    /**
     * Usage: StartCoroutine(CoroutineHelper.Chain(...))
     * For example:
     *     StartCoroutine(CoroutineHelper.Chain(
     *         CoroutineHelper.Do(() => Debug.Log("A")),
     *         CoroutineHelper.WaitForSeconds(2),
     *         CoroutineHelper.Do(() => Debug.Log("B"))));
     */

    public static IEnumerator Chain(params IEnumerator[] actions)
    {
        foreach (IEnumerator action in actions)
        {
            yield return action;
        }
    }

    /**
     * Usage: StartCoroutine(CoroutineHelper.WaitForSeconds(seconds))
    */
    public static IEnumerator DelaySeconds(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
    public static IEnumerator DelayOneFixedFrame(Action action)
    {
        yield return new WaitForFixedUpdate();
        action();
    }

    public static IEnumerator WaitUntil(Func<bool> predicate)
    {
        yield return new WaitUntil(predicate);
    }
    public static IEnumerator WaitWhile(Func<bool> predicate)
    {
        yield return new WaitWhile(predicate);
    }

    public static IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public static IEnumerator WaitForSecondsRealTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
    }

    public static IEnumerator WaitForEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
    }

    public static IEnumerator WaitForFixedUpdate()
    {
        yield return new WaitForFixedUpdate();
    }

    public static IEnumerator Do(Action action)
    {
        action();
        yield return 0;
    }
}