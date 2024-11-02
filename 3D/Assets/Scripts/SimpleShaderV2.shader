Shader "PF3311/Simple Shader V2"
{

    Properties
    {
        _MainTexture ("Texture", 2D) = "white" {}
    }


    SubShader{

        Pass
        {
            CGPROGRAM            
            #pragma vertex vertices
            #pragma fragment fragments

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct FromVertToFrag{
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTexture;

            FromVertToFrag vertices (appdata v)
            {
                FromVertToFrag o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }


            float4 fragments (FromVertToFrag i) : SV_TARGET
            {
                return tex2D(_MainTexture, i.uv);
            }
            
            ENDCG


        }



    }
}