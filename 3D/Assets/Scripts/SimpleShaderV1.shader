Shader "PF3311/Simple Shader V1"
{

    Properties
    {
        _MainColor("Main Color", Color) = (1,1,1,1)
    }


    SubShader{

        Pass
        {
            CGPROGRAM            
            #pragma vertex vertices
            #pragma fragment fragments

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct FromVertToFrag{
                float4 vertex : SV_POSITION;
            };

            float4 _MainColor;

            FromVertToFrag vertices (appdata v)
            {
                FromVertToFrag o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }


            float4 fragments (FromVertToFrag i) : SV_TARGET
            {
                return _MainColor;
            }
            
            ENDCG


        }



    }
}