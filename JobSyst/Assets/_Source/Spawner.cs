using System.Collections;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _probePref;
    [SerializeField] int _maxProbesAmount;
    [SerializeField] float _speed;
    [SerializeField] private float _timeToWait;


    private Transform[] _spawnedObjects;
    private TransformAccessArray _spawnedTransformsAccess;

    void Start()
    {
        _spawnedObjects = new Transform[_maxProbesAmount];
        for (int i = 0; i < _maxProbesAmount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-100, 100), 5.5f, Random.Range(-100, 100));
           
            GameObject _newProbe = Instantiate(_probePref, position, Quaternion.identity);
            _spawnedObjects[i] = _newProbe.transform;

        }
        _spawnedTransformsAccess = new TransformAccessArray(_spawnedObjects);
        StartCoroutine(SolveLog());

    }

    
    void Update()
    {
       
        Spiner _spiner = new Spiner()
        {
            Speed = _speed,
        };
        JobHandle spinerJobHandel = _spiner.Schedule(_spawnedTransformsAccess);
        spinerJobHandel.Complete();
    }
    IEnumerator SolveLog()
    {
        yield return new WaitForSeconds(_timeToWait);

        NativeArray<int> _randomNumbers = new NativeArray<int>(_maxProbesAmount,Allocator.Persistent);
        for (int i = 0; i < _maxProbesAmount; i++)
        {
            _randomNumbers[i] = Random.Range(0, 100);
        }

        LogSolve _logSolve = new LogSolve()
        {
            RandomNumbers = _randomNumbers
        };
        JobHandle logSolveJobHandle = _logSolve.Schedule(); 
        logSolveJobHandle.Complete();
    }
}
