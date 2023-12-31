using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ActionManager : MonoBehaviour
{
    [SerializeField] private float _startTimerValue;
    private float _timer;
    private Spawner _spawner;
    private RandomEvents _randomEvents;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _randomEvents = FindObjectOfType<RandomEvents>();
    }

    private void Start()
    {
        _timer = _startTimerValue;
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            int randomIndex = Random.Range(0, 3);
            int randomCount = Random.Range(1, 4);

            _spawner.SpawnRandomEnemies(randomCount);
            switch (randomIndex)
            {
                case 0:
                    _spawner.SpawnRandomEnemies(randomCount);
                    break;
                case 1:
                    _spawner.SpawnRandomStuff(1);
                    break;
                case 2:
                    int indexOfEvent = Random.Range(0, 3);
                    switch (indexOfEvent)
                    {
                        case 0:
                            _randomEvents.Block();
                            break;
                        case 1:
                            _randomEvents.ChangeGravity();
                            break;
                        case 2:
                            _randomEvents.ChangeScale();
                            break;
                    }
                    break;
            }
            _timer = _startTimerValue;
        }
    }
}
