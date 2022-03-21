using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicRecordsREST.Models;

namespace MusicRecordsREST.Manager
{
    public class MusicRecordManager
    {
        private static List<MusicRecordsData> data = new List<MusicRecordsData>()
        {
            new MusicRecordsData() {Title = "Bodega mama", Artist = "Kim Larsen", Duration = 4, PublicationYear = 2000},
            new MusicRecordsData() {Title = "Sut den op fra slap", Artist = "Suspekt", Duration = 2, PublicationYear = 2015},
            new MusicRecordsData() {Title = "Vi maler byen rød", Artist = "Birthe Kjær", Duration = 3, PublicationYear = 1970},
            new MusicRecordsData() {Title = "In da club", Artist = "50 Cent", Duration = 5, PublicationYear = 2002}
        };

        public List<MusicRecordsData> GetAll(string? Title, string? Artist, int? Duration, int? PublicationYear)
        {
            List<MusicRecordsData> result = new List<MusicRecordsData>(data);
            
            if (!string.IsNullOrWhiteSpace(Title))
            {
                result = result.FindAll(filterTitle =>
                    filterTitle.Title.Contains(Title, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(Artist))
            {
                result = result.FindAll(filterArtist =>
                    filterArtist.Artist.Contains(Artist, StringComparison.OrdinalIgnoreCase));
            }

            if (Duration != null)
            {
                result = result.FindAll(filterDuration => filterDuration.Duration == Duration);
            }

            if (PublicationYear != null)
            {
                result = result.FindAll(filterPublicationYear =>
                    filterPublicationYear.PublicationYear == PublicationYear);
            }
            {
                
            }

            return result;
        }


    }
}
