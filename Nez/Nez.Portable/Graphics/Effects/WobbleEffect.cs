using System;
using Microsoft.Xna.Framework.Graphics;


namespace Nez
{
	public class WobbleEffect : Effect
	{
        /// <summary>Timer/GameTime for animating the effect</summary>
        public float Timer
        {
			get { return _timer; }
			set
			{
				if(_timer != value )
				{
                    _timer = value;
					_timerParam.SetValue(_timer);
				}
			}
		}

        /// <summary>Refraction Amount.</summary>
        /// <minValue>20</minValue>
        /// <maxValue>60</maxValue>
        /// <defaultValue>50</defaultValue>
        public float Refracton
        {
            get { return _refraction; }
            set
            {
                if (_refraction != value)
                {
                    _refraction = value;
                    _refractionParam.SetValue(_refraction);
                }
            }
        }

        /// <summary>Vertical trough</summary>
        /// <minValue>20</minValue>
        /// <maxValue>30</maxValue>
        /// <defaultValue>23</defaultValue>
        public float VerticalTroughWidth
        {
            get { return _verticalThroughWidth; }
            set
            {
                if (_verticalThroughWidth != value)
                {
                    _verticalThroughWidth = value;
                    _verticalThroughWidthParam.SetValue(_verticalThroughWidth);
                }
            }
        }


        /// <summary>Center X of the Zoom.</summary>
        /// <minValue>20</minValue>
        /// <maxValue>30</maxValue>
        /// <defaultValue>23</defaultValue>
        public float Wobble2
        {
            get { return _wobble2; }
            set
            {
                if (_wobble2 != value)
                {
                    _wobble2 = value;
                    _wobble2Param.SetValue(_wobble2);
                }
            }
        }

        float _timer = 0.0f;
        float _refraction = 50.0f;
        float _verticalThroughWidth = 23.0f;
        float _wobble2 = 23.0f;


		EffectParameter _timerParam;
        EffectParameter _verticalThroughWidthParam;
        EffectParameter _wobble2Param;
        EffectParameter _refractionParam;


        public WobbleEffect() : base( Core.graphicsDevice, EffectResource.wobbleBytes )
		{

            _timerParam = Parameters["Timer"];
            _timerParam.SetValue(_timer);


            _refractionParam = Parameters["Refracton"];
            _refractionParam.SetValue(_refraction);

            _verticalThroughWidthParam = Parameters["VerticalTroughWidth"];
            _verticalThroughWidthParam.SetValue(_verticalThroughWidth);


            _wobble2Param = Parameters["Wobble2"];
            _wobble2Param.SetValue(_wobble2);
        }
	}
}

