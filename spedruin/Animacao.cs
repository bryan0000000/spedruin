namespace spedruin;
public partial class Animacao : ContentPage
{
 protected List<String> Animacao1 = new List<String>();
 protected List<String> Animacao2 = new List<String>();
 protected List<String> Animacao3 = new List<String>();
 
 protected bool loop=true;
 protected int AnimacaoAtiva =1;

bool Parado=true;
int FrameAtual=1;
protected Image compImage;
public Animacao (Image a)
{
 compImage=a;
}

public void Para()
{
 Parado=true;
}
public void anda()
{
  Parado=false;
}
 public void SetAnimacaoAtiva(int a)
 {
    AnimacaoAtiva=a;
 }
}