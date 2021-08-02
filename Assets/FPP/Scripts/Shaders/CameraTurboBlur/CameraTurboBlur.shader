Shader "Custom/Camera/TurboBlur"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
            #include "UnityCG.cginc"

			float4 _Color;
			float _Radius;
			float _Softness;
			sampler2D _MainTex;
			float4 _GlitchColor;

			float4 frag(v2f_img input) : COLOR
			{
				float4 base = tex2D(_MainTex, input.uv);
                base = base * _Color;

				float distanceFromCenter = distance(input.uv.xy, float2(0.5, 0.5));
				float vignette = smoothstep(_Radius, _Radius - _Softness, distanceFromCenter);
				base = saturate(base * vignette);
				
				return base;
			}

			ENDCG
		}
	}
}