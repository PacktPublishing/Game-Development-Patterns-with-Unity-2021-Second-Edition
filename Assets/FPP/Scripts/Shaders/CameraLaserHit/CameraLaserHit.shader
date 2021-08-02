Shader "Custom/Camera/LaserHit"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
            #include "UnityCG.cginc"
			
			sampler2D _MainTex;
			float4 _Color;

			float4 frag(v2f_img input) : COLOR
			{
				float4 base = tex2D(_MainTex, input.uv);
                base = base * _Color;
				return base;
			}
			ENDCG
		}
	}
}