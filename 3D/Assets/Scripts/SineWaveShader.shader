Shader "PF3311/Sine Wave Shader"
{

    Properties
    {
        _Modifier("Modifier", float) = 0
        _Amplitude("Amplitude", float) = 0
        _Color("Color", Color) = (1,1,1,1)
        _Waves("Waves" , float) = 1
    }


    SubShader{

 

        Pass
        {
            CGPROGRAM            
            #pragma vertex vertices
            #pragma fragment fragments
            #pragma glsl

            #include "UnityCG.cginc"

            struct appdata
            {
                half4 vertex : POSITION;
            };

            struct FromVertToFrag{
                float4 vertex : SV_POSITION;
                float4 other : COLOR;
            };

            uniform fixed4 _Color;
            uniform fixed _Modifier;
            uniform fixed _Amplitude;
            uniform fixed _Waves;

            FromVertToFrag vertices (appdata v)
            {
                FromVertToFrag o;
                fixed xValue = v.vertex.x * 3.14159 * _Waves;  
                fixed zValue = v.vertex.z * 3.14159 * _Waves;  
                fixed distance = sqrt(xValue*xValue + zValue*zValue) + _Modifier;
                v.vertex.y = sin(distance) * _Amplitude;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.other = v.vertex;
                return o;
            }


            float4 fragments (FromVertToFrag i) : SV_TARGET
            {
                float4 newColor;
                newColor.r = _Color.x ;
                newColor.g = _Color.y * i.other.y * _Amplitude * _Waves * 20;
                newColor.b = _Color.z;
                return newColor;
            }
            
            ENDCG


        }



    }
}