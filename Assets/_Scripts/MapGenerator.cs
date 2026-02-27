using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap MojaMapa;
    public TileBase Trawa;
    public TileBase Trawa2;
    public TileBase Trawa3;

    public TileBase Woda_lewy_gorny;
    public TileBase Woda_srode_gorny;
    public TileBase Woda_prawy_gorny;
    public TileBase Woda_lewy_srodek;
    public TileBase Woda_srodek_srodek;
    public TileBase Woda_prawy_srodek;
    public TileBase Woda_lewy_dolny;
    public TileBase Woda_srodek_dolny;
    public TileBase Woda_prawy_dolny;
    

    public int rozmiar = 30;

    void Start()
    {
        Map_Generator();
    }

    void Map_Generator()
    {
        MojaMapa.ClearAllTiles();

        // ETAP 1: Kładziemy "dywan" z trawy
        for (int x = -rozmiar / 2; x < rozmiar / 2; x++)
        {
            for (int y = -rozmiar / 2; y < rozmiar / 2; y++)
            {
            // Losujemy od 0 do 100
            int losTrawy = Random.Range(0, 40);
            TileBase wybranaTrawa;

            // Ustawiamy szanse 
            if (losTrawy < 5) 
            {
                wybranaTrawa = Trawa;
            } 
            else if (losTrawy < 35)
            {
                wybranaTrawa = Trawa2;
            } else 
            {
                wybranaTrawa = Trawa3;
            }

            MojaMapa.SetTile(new Vector3Int(x, y, 0), wybranaTrawa);
            }
        }

        // ETAP 2: Malujemy jeziora na gotowej trawie
        for (int x = -rozmiar / 2; x < rozmiar / 2; x++)
        {
            for (int y = -rozmiar / 2; y < rozmiar / 2; y++)
            {
                int los = Random.Range(0, 100);

                if (los > 97) // Zmniejszyłem szansę, żeby jeziora nie były wszędzie
                {
                    // SPRAWDZANIE: czy w promieniu np 3 kafelków jest już woda?
                    if (CzyMogeTuPostawicWode(x, y))
                    {
                    PostawJezioro(x, y);
                    }
                }
                // MIEJSCE NA TWOJE PRZYSZŁE POMYSŁY:
                // else if (los < 5) 
                // {
                //    MojaMapa.SetTile(new Vector3Int(x, y, 0), Kamien);
                // }
            }
        }
    }

    void PostawJezioro(int x, int y)
    {
        MojaMapa.SetTile(new Vector3Int(x, y, 0), Woda_srodek_srodek);
        MojaMapa.SetTile(new Vector3Int(x - 1, y + 1, 0), Woda_lewy_gorny);
        MojaMapa.SetTile(new Vector3Int(x + 1, y + 1, 0), Woda_prawy_gorny);
        MojaMapa.SetTile(new Vector3Int(x - 1, y - 1, 0), Woda_lewy_dolny);
        MojaMapa.SetTile(new Vector3Int(x + 1, y - 1, 0), Woda_prawy_dolny);
    }

    bool CzyMogeTuPostawicWode(int centerX, int centerY)
    {
        int dystansBezpieczenstwa = 3; // Jak blisko siebie mogą być środki jezior?

        for (int i = -dystansBezpieczenstwa; i <= dystansBezpieczenstwa; i++)
        {
            for (int j = -dystansBezpieczenstwa; j <= dystansBezpieczenstwa; j++)
            {
                TileBase tile = MojaMapa.GetTile(new Vector3Int(centerX + i, centerY + j, 0));

                // Jeśli jakikolwiek kafelek w okolicy to woda, zwracamy "Fałsz"
                if (tile == Woda_srodek_srodek || tile == Woda_lewy_gorny || 
                tile == Woda_prawy_gorny || tile == Woda_lewy_dolny || 
                tile == Woda_prawy_dolny)
                {
                    return false;
                }
            }
        }
        return true; // Jeśli pętla nie znalazła wody, można stawiać
    }
}