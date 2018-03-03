using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Actions;
using Urho.Resources;

namespace LuckyMeApp.ViewModel
{
    public class GroupsViewModel : Application
    {
        public GroupsViewModel() { }
        public GroupsViewModel(ApplicationOptions options) : base(options) { }

        protected override async void Start()
        {
            base.Start();

            try
            {
                await Create3DObject();
            }
            catch (Exception e)
            {
                int x = 2;
            }
            
        }
        private Material boxMaterialDefault;
        private Material boxMaterialSelected;

        private async Task Create3DObject()
        {

            boxMaterialDefault = ResourceCache.GetMaterial(@"C:\Users\liran\Desktop\Xamarin\LuckyMeApp\LuckyMeApp\LuckyMeApp\LuckyMeApp\Models\myBox.mdl");




            //boxMaterialSelected = Application.ResourceCache.GetMaterial("Materials/GameBoxSelected.xml");

            // Scene
            var scene = new Scene();
            scene.CreateComponent<Octree>();

            var mushroom = scene.CreateChild("Mushroom");
            mushroom.Position = new Vector3(90 - 45, 0, 90 - 45);
            mushroom.Rotation = new Quaternion(0, 180, 0);
            mushroom.SetScale(0.5f + 15000 / 10000.0f);
            var mushroomObject = mushroom.CreateComponent<StaticModel>();
            mushroomObject.Model = ResourceCache.GetModel(@"C:\Users\liran\Desktop\Xamarin\LuckyMeApp\LuckyMeApp\LuckyMeApp\LuckyMeApp\Models\myBox.mdl");


            // Node (Rotation and Position)
            Node node = scene.CreateChild();
            node.Position = new Vector3(0, 0, 5);
            node.Rotation = new Quaternion(10, 60, 10);
            node.SetScale(1f);

            // Pyramid Model
            StaticModel modelObject = node.CreateComponent<StaticModel>();
            modelObject.Model = ResourceCache.GetModel(@"C:\Users\liran\Desktop\Xamarin\LuckyMeApp\LuckyMeApp\LuckyMeApp\LuckyMeApp\Models\myBox.mdl");

            // Light
            Node light = scene.CreateChild(name: "light");
            light.SetDirection(new Vector3(0.4f, -0.5f, 0.3f));
            light.CreateComponent<Light>();

            // Camera
            Node cameraNode = scene.CreateChild(name: "camera");
            Camera camera = cameraNode.CreateComponent<Camera>();

            // Viewport
            Renderer.SetViewport(0, new Viewport(scene, camera, null));

            // Action
            await node.RunActionsAsync(
                new RepeatForever(new RotateBy(duration: 1,
                    deltaAngleX: 0, deltaAngleY: 90, deltaAngleZ: 0)));

        }
    }
}
