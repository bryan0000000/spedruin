
using FFImageLoading.Maui;
namespace spedruin;

public partial class MainPage : ContentPage
{

bool EstaNoChao=true;
bool EstaNoAr=false;

bool Estamorto=false;
bool EstaPulando=false;
const int Forcapulo=15;
const int maxTempoPulando=8;
const int maxTemponoAr=4;
const int TempoEntreFrames=30;
const int ForcaGravidade=6;
int tempoPulando=0;
int velo1=1;
int temponoAr=0;
int velo2=2;
int velo3=3;
int velo=0;
int LarguraDaJanela=0;
int AlturaDaJanela=0;
Inimigos inimigos;
Player jogador;

   public MainPage()
	{
		InitializeComponent();
		jogador = new Player(gatolol);
		jogador.Corre();
	}

 

   
   
  protected override void OnSizeAllocated(double w, double h)
   {
     base.OnSizeAllocated(w, h);
     CorrigeTamanhoCenario(w,h);
     CalculaVelo(w);
	 inimigos=new Inimigos(-w);
	 inimigos.Add(new Inimigo(imgInimigo1));
	 inimigos.Add(new Inimigo(imgInimigo2));
     inimigos.Add(new Inimigo(imgInimigo3));
     inimigos.Add(new Inimigo(imgInimigo4));

   }


void CalculaVelo(double w)
{
	velo1 = (int)(w*0.002);
	velo2 = (int)(w*0.004);
	velo3 = (int)(w*0.008);
	velo  = (int)(w*0.01);
}
void CorrigeTamanhoCenario(double w, double h)
{
	foreach(var A in HS1.Children)
	(A as Image).WidthRequest=w;

	foreach(var A in HS2.Children)
	(A as Image).WidthRequest=w;

	foreach(var A in HS3.Children)
	(A as Image).WidthRequest=w;

	HS1.WidthRequest=w*2;
	HS2.WidthRequest=w*2;
	HS3.WidthRequest=w*2;
}

	  protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenhar();
    }

	async Task Desenhar()
  {     
		while (!Estamorto)
		{
			GerenciaCenas();
			if (inimigos != null)
			inimigos.Desenha(velo);

			if (!EstaPulando && !EstaNoAr)
			{
				AplicaGavidade();
				jogador.Desenha();
			}
			else
				AplicaPulo();
			await Task.Delay(TempoEntreFrames);
		}
	}

 void GerenciaCenas()
 {
	MoveCena();
	GerenciaCena(HS1);
	GerenciaCena(HS2);
	GerenciaCena(HS3);
 }
 void MoveCena()
 {
	HS1.TranslationX-=velo1;
	HS2.TranslationX-=velo2;
	HS3.TranslationX-=velo3;
 }
 void GerenciaCena(HorizontalStackLayout hsl)
 {
	var view =(hsl.Children.First() as Image);
	if(view.WidthRequest + hsl.TranslationX < 0)
	{
		hsl.Children.Remove(view);
		hsl.Children.Add(view);
		hsl.TranslationX=view.TranslationX;
	}
 }


 void AplicaGavidade()
 {
	if(jogador.GetY ()<0)
	   jogador.MoveY(ForcaGravidade);
	else if (jogador.GetY()>=0)
	{
		jogador.SetY(0);
		EstaNoChao=true;
	}
 }

 void AplicaPulo()
 {
 EstaNoChao=false;
 if(EstaPulando && tempoPulando >= maxTempoPulando)
 {
	EstaPulando=false;
	EstaNoAr=true;
	temponoAr=0;
 }
 else if( EstaNoAr && temponoAr >= maxTemponoAr)
 {
	EstaPulando=false;
	EstaNoAr=false;
	tempoPulando=0;
	temponoAr=0;
 }
 else if(EstaPulando && tempoPulando < maxTempoPulando)
 {
	jogador.MoveY (-Forcapulo);
	tempoPulando++;
 }
 else if (EstaNoAr)
          temponoAr++;
 }
 	void OnGridTapped(object o, TappedEventArgs a)
	{
		if (EstaNoChao)
			EstaPulando = true;
	}

}


