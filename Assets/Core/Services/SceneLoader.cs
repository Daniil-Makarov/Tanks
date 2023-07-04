using UnityEngine;
using UnityEngine.SceneManagement;

namespace progdamn.Core.Services {
	public class SceneLoader {
		public void RestartGame() => LoadSceneById(GetActiveSceneId());

		private void LoadSceneById(int id) => SceneManager.LoadScene(id);

		private int GetActiveSceneId() => SceneManager.GetActiveScene().buildIndex;
	}
}