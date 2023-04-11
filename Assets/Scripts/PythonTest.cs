using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;

public class PythonTest : MonoBehaviour
{
    [SerializeField]
    TextAsset pythonScript;

    // Use this for initialization
    void Start()
    {
        var scriptCreator = new PythonScriptCreator(pythonScript);
        scriptCreator.CallScript();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class PythonScriptCreator
{
    string script;
    Microsoft.Scripting.Hosting.ScriptEngine scriptEngine;
    Microsoft.Scripting.Hosting.ScriptScope scriptScope;
    Microsoft.Scripting.Hosting.ScriptSource scriptSource;

    public PythonScriptCreator(TextAsset PythonFile)
    {
        this.script = PythonFile.text;
        this.scriptEngine = Python.CreateEngine();

        scriptEngine.Runtime.LoadAssembly(typeof(GameObject).Assembly);
        this.scriptScope = scriptEngine.CreateScope();
        this.scriptSource = scriptEngine.CreateScriptSourceFromString(script);



        var log = new Log();
        log.debugLog();
        this.scriptScope.SetVariable("scope", log);
        log.debugLog();
    }

    public void CallScript()
    {
        this.scriptSource.Execute(this.scriptScope);
    }
}

public class Log
{
    public int testInt = 0;

    public void debugLog()
    {
        Debug.Log("Debug Log " + testInt);
    }
}
