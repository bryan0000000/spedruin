namespace spedruin;
public partial class Animacao : ContentPage
{
 protected List<String> Animacao1 = new List<String>();
 protected List<String> Animacao2 = new List<String>();
 protected List<String> Animacao3 = new List<String>();
 
 protected bool loop=true;
 protected int AnimacaoAtiva =1;

bool Parado=false;
int FrameAtual=1;
protected Image compImage;
public Animacao (Image a)
{
 compImage=a;
}

public void Para()
{
 Parado=false;
}
public void anda()
{
  Parado=false;
}
 public void SetAnimacaoAtiva(int a)
 {
    AnimacaoAtiva=a;
 }
 public void Desenhar()
 {
    if(Parado)
    return;
     String nomeArgivo="";
     int TamanhoAnimacao=1;
     if(AnimacaoAtiva==1)
     {
       nomeArgivo= Animacao1 [FrameAtual];
       TamanhoAnimacao = Animacao1.Count;
     }
    else if (AnimacaoAtiva==2)
     {
       nomeArgivo= Animacao2 [FrameAtual];
       TamanhoAnimacao = Animacao2.Count;
    
     }
    else if (AnimacaoAtiva==3)
     {
       nomeArgivo= Animacao3 [FrameAtual];
       TamanhoAnimacao = Animacao3.Count;
  }
   if (FrameAtual>=TamanhoAnimacao)
    {

      if(loop)
         FrameAtual=0;
      else
      {
        Parado=true;
        QuandoParar();
      }
    }
 }
public virtual void QuandoParar()
{

}

}