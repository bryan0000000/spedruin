using spedruin;

public delegate void Callback();

public class Player:Animacao
{
  public Player (Image a):base (a)
  {
  for (int i=1; i<=12;++i)
       Animacao1.Add($"gato.{i.ToString("D2")}.png");

         for (int i=1; i<=1;++i)
       Animacao2.Add($"gato.{i.ToString("D2")}.png");

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
   anda();
  }
}



