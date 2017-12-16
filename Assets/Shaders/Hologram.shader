Shader "Unlit/Hologram"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_TintColor("Texture", color) = (1,1,1,1) 
		_Transparency("Transparency", Range(0.0, 0.5)) = 0.25
		_CutoutThresh("Cutout Threshold", Range(0.0, 1.0)) = 0.2
		_Distance("Distance", float) = 1
		_Amplitude("Amplitude", float) = 1
		_Speed("Speed", float) = 1
		_Amount("Amount", float) = 1
	}
	SubShader
	{
		//Queue Transparent to render last than anything else, just before Overlay on the render queue.
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _TintColor;
			float _Transparency;
			float _CutoutThresh;
			float _Distance;
			float _Amplitude;
			float _Speed;
			float _Amount;

			
			v2f vert (appdata v)
			{
				v2f o;
				//_Time.y comes from unity as a float 4. y is the time in seconds.
				//Same as Time.time
				v.vertex.x += sin(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				//If do not wanted to multiply change the + sing to *
				fixed4 col = tex2D(_MainTex, i.uv) + _TintColor;
				col.a = _Transparency;
				//Cut out the amount of red.
				clip(col.r - _CutoutThresh);
				return col;
			}
			ENDCG
		}
	}
}
