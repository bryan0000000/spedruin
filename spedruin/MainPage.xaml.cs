namespace spedruin;

public partial class MainPage : ContentPage
{
bool Estamorto=false;
bool EStarpulando=false;
const int TempoEntreFrames=25;
int velo1=0;
int velo2=0;
int velo3=0;
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
	(A as Imagre).WidthRequest=w;

	foreach(var A in HS2.Children)
	(A as Imagre).WidthRequest=w;

	foreach(var A in HS3.Children)
	(A as Imagre).WidthRequest=w;

	HS1.WidthRequest=w*1.5;
	HS2.WidthRequest=w*1.5;
	HS3.WidthRequest=w*1.5;

}

}


