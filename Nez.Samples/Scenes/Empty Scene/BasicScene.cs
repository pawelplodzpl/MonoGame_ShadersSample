using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Nez.Samples
{

    public class myComponent : Component, IUpdatable
    {

        float timeSinceLastReset = 0.0f;
        float timeToWait = 0.1f;


        public void update()
        {

            timeSinceLastReset += Time.deltaTime;
            if (timeSinceLastReset > timeToWait)
            {
                var player = Nez.Core.scene.findEntity("moon");
                var material = player.getComponent<Sprite>().material;
                var effect = material.effect;
                var parameters = effect.Parameters;
                parameters["_attenuation"].SetValue(Nez.Random.nextFloat(1.0f));
                parameters["_linesFactor"].SetValue(100* Nez.Random.nextFloat(6.0f));
                timeSinceLastReset = 0.0f;

            }

        }

    }

    public class mySecondComponent : Component, IUpdatable
    {
        int timer = 0;

        public void update()
        {
            timer++;
            var player = Nez.Core.scene.findEntity("moon");
            var material = player.getComponent<Sprite>().material;
            var effect = material.effect;
            var parameters = effect.Parameters;
            parameters["Timer"].SetValue((float)timer / 10.0f);

        }
    }


    [SampleScene( "Basic Scene", 9999, "Scene with a single Entity. The minimum to have something to show" )]
	public class BasicScene : SampleScene
	{
		public override void initialize()
		{
			base.initialize();


            //var test = content.loadNezEffect<ScanlinesEffect>();
            //test.attenuation = 1.0f;
            //test.linesFactor = 20.0f;

            var test = content.loadNezEffect<WobbleEffect>();

            var material = new Material(test);

            // default to 1280x720 with no SceneResolutionPolicy
            setDesignResolution( 1280, 720, Scene.SceneResolutionPolicy.None );
			Screen.setSize( 1280, 720 );

			var moonTex = content.Load<Texture2D>( Content.Shared.moon );
			var playerEntity = createEntity( "moon", new Vector2( Screen.width / 2, Screen.height / 2 ) );
            var testSprite = new Sprite(moonTex);
            testSprite.material = material;
			playerEntity.addComponent( testSprite );

            //playerEntity.addComponent<myComponent>();
            playerEntity.addComponent<mySecondComponent>();


        }
	}
}

