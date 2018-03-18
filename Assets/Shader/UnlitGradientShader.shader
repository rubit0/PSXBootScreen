Shader "Rubito/UnlitGradientShader"
{
	Properties
	{
		_StartColor("StartColor", Color) = (0.9, 0.8, 0,1)
		_EndColor("EndColor", Color) = (0.8, 0.2, 0, 1)
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform float4 _StartColor;
			uniform float4 _EndColor;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float3 col = lerp(_StartColor.rgb, _EndColor.rgb, i.uv.r);
				return fixed4(col, 1);
			}
			ENDCG
		}
	}
}
