Shader "Custom/AsteroidSizes" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_BumpMap("Bumpmap", 2D) = "bump" {}
		_BumpScale("Normal ", Float) = 1
		_HeightMap("Height Map", 2D) = "white" {}
		_HeightMapScale("Height", Range(-2,2)) = 1
		_Distance("Distance", float) = 1
		_Speed("Speed", float) = 1
		_Amount("Extrusion Amount", Range(0,10)) = 0.5
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
#pragma surface surf Lambert vertex:vert
	struct Input {
		float2 uv_BumpMap;
		float2 uv_MainTex;
		float2 uv_HeightMap;
	};
	sampler2D _BumpMap;
	sampler2D _HeightMap;
	float _Speed = 1;
	float _Amount = 1;
	float _Distance = 0.1;
	float _HeightMapScale = 1;

	void vert(inout appdata_full v) {
		v.vertex.x += sin( _Speed + v.vertex.y * _Amount) * _Distance;
		v.vertex.z += sin(_Speed + v.vertex.x * _Amount) * _Distance;
		v.vertex.yz += sin(_Speed + v.vertex.z * _Amount) * _Distance;
		float4 heightMap = tex2Dlod(_HeightMap, float4(v.texcoord.xy, 0, 0));
		v.vertex.xyz += heightMap.b * _HeightMapScale;
	}
	sampler2D _MainTex;
	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	}
	ENDCG
	}
		Fallback "Diffuse"
}