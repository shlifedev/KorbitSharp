# KorbitSharp
`
 비트코인 거래소 코빗API의 C#구현.  
`
 
## 사용법

KorbitClient 객체를 생성후 Login함수로 어세스토큰 획득 이후 프로그래밍.

 ```cs
KorbitClient client = new KorbitClient($ClientId,$ClientSecret); 

client.Login(false);
client.CallAPI();

 
 ```

현재 api 추가중.. 짬날때마다 추가예정.
