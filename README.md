# KorbitSharp

 비트코인 거래소 코빗API의 C#구현. 재미로 비트코인 거래용 AI 혹은 유틸리티를 만들기 위해 구현중.  
 시간이 날때마다 짬내서 완성시켜놓을 예정
 
 
## 사용법

KorbitClient 객체를 생성후 Login함수로 어세스토큰 로그인 이후 프로그래밍.

 ```cs
KorbitClient client = new KorbitClient($ClientId,$ClientSecret);
client.Login((success)=>{ 

});

 
 ```
현재 api 추가중..
