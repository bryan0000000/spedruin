using FFImageLoading.Maui;

namespace spedruin
{
    public delegate void CallBack();
    public class Player:Animacao
    {
        public Player(CachedImageView a): base(a)
        {
            for(int numero = 1; numero <= 12; numero++)
                Animacao1.Add($"gato{numero.ToString("D2")}.png");

            for(int numero2 = 1; numero2 <= 2; numero2++)
                Animacao2.Add($"morto{numero2.ToString("D2")}.png");
            SetAnimacaoAtiva(1);
        }

        public void Morto()
        {
            loop = false;
            SetAnimacaoAtiva(2);
        }

        public void Run()
        {
            loop = true;
            SetAnimacaoAtiva(1);
          Corre();
        }

    }
}



