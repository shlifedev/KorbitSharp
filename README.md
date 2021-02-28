# KorbitSharp


 비트코인 거래소 코빗API의 C#구현.  
 모든 API가 구현되어있는건 아닙니다.
 

 
## 사용법

KorbitClient 객체를 생성후 Login함수로 어세스토큰 획득 이후 코드를 작성하세요.

 ```cs
 
void Method1()
{
   KorbitClient client = new KorbitClient($ClientId,$ClientSecret);  
   client.Login(false);
   client.SomethingAPI..(); 
}
 ```

현재 api 추가중.. 짬날때마다 추가예정.
