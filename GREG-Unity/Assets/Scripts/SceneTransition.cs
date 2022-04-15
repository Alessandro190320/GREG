using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public Animator transition;
    public VectorValue initialPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int indexFloor = SceneManager.GetActiveScene().buildIndex;
            int indexFloorLiceo = SceneManager.GetActiveScene().buildIndex;

            // se nell'opggetto contiene licero, vado a selezionare iil piano per quanto riguarda il liceo
            // in caso contrario spostarsi sul piano dell'itis
            if(!name.Contains("liceo")){
                if (name.Contains("up"))
                    indexFloor++;
                else if (name.Contains("down"))
                    indexFloor--;
            }
            else {
                if (name.Contains("up"))
                    indexFloorLiceo++;
                else if (name.Contains("down"))
                    indexFloorLiceo--;
            }

            PlayerState.setPosition(initialPosition);
            LevelSystem.current.ChangeScene(indexFloor);
        }
    }
}
// Sessione remota test 15-04-2022 
// ciao David 
// ciao Marcheselli
