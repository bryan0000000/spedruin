

namespace spedruin;

public partial class MainPage : ContentPage
{
bool Estamorto=false;
bool EStarpulando=false;
const int TempoEntreFrames=25;
int velo1=1;
int velo2=2;
int velo3=3;
int velo=0;
int LarguraDaJanela=0;
int AlturaDaJanela=0;

   public MainPage()
	{
		InitializeComponent();
	}

 

   
   
  protected override void OnSizeAllocated(double w, double h)
   {
     base.OnSizeAllocated(w, h);
     CorrigeTamanhoCenario(w,h);
     CalculaVelo(w);
   }


void CalculaVelo(double w)
{
	velo1 = (int)(w*0.001);
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
	while(!Estamorto)
	{
		GerenciaCenas();
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
	var view =(hsl.Children.First()as Image);
	if(view.WidthRequest + hsl.TranslationX < 0)
	{
		hsl.Children.Remove(view);
		hsl.Children.Add(view);
		hsl.TranslationX=view.TranslationX;
	}
 }

}


