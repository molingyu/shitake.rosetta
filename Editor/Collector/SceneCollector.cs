using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;


namespace Rosetta.Editor.Collector
{
    [Serializable]
    public class SceneCollector : PrefabCollectorBase
    {
        public List<SceneAsset> SceneList = new List<SceneAsset>();

        public override void Collect(string space)
        {
            EditorSceneManager.SaveOpenScenes();
            SceneList.ForEach(sceneAsset =>
            {
                var scene = EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(sceneAsset), OpenSceneMode.Single);
                GameObjects = scene.GetRootGameObjects().ToList();
                PrefixName = $"Scene[{scene.name}]:";
                base.Collect(space);
            });
        }
    }
}    