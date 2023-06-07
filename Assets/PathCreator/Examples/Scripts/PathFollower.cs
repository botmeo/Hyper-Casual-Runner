using UnityEngine;

namespace PathCreation.Examples
{
    public class PathFollower : MonoBehaviour
    {
        private static PathFollower instance;
        public static PathFollower Instance { get => instance; }

        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float pathProgress { get; private set; }
        public float speed = 5;
        private float distanceTravelled;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        private void Update()
        {
            if (pathCreator != null && GameManager.Instance.gameStarted && !GameManager.Instance.gameWon && !GameManager.Instance.gameLost)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                transform.eulerAngles += new Vector3(0, 0, 90);

                pathProgress = pathCreator.path.GetPercentage(distanceTravelled);
            }
        }

        private void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}