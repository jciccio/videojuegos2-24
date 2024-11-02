Shader "PF3311/Simple Shader V0"
{

    Properties
    {
        _GreenAmount("Green Amount" , Float) = 1
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

            float _GreenAmount;
            float4 _MainColor;


            FromVertToFrag vertices (appdata v)
            {
                FromVertToFrag o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }


            float4 fragments (FromVertToFrag i) : SV_TARGET
            {
                return float4(0,_GreenAmount,0,1);
            }
            
            ENDCG


        }



    }
}