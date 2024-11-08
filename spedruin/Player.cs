using spedruin;

public delegate void Callback();

public class Player:Animacao
{
 void Play ()
 {
  Corre();
 }
 
   
 
  public Player (Image a):base (a)
  {
  for (int i=1; i<=01;++i)
       Animacao1.Add($"gato{i.ToString("D2")}.png");




       SetAnimacaoAtiva(1);
  }
  public void Morre ()
  {
    loop=false;
    SetAnimacaoAtiva(2);
  }
  public void Corre()
  {
   loop=true;
   SetAnimacaoAtiva(1);
   
  }
}



