using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicRecordsREST.Models;

namespace MusicRecordsREST.Manager
{
    public class MusicRecordDBManager
    {
        private MusicRecordContext _recordContext;

        public MusicRecordDBManager(MusicRecordContext context)
        {
            _recordContext = context;
        }

        public List<MusicRecordsData> GetAll(string? Title, string? Artist, int? Duration, int? PublicationYear)
        {
            IEnumerable<MusicRecordsData> result = _recordContext.MusicRecords;

            if (!string.IsNullOrWhiteSpace(Title))
            {
                result = result.ToList().FindAll(filterTitle =>
                    filterTitle.Title.Contains(Title, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(Artist))
            {
                result = result.ToList().FindAll(filterArtist =>
                    filterArtist.Artist.Contains(Artist, StringComparison.OrdinalIgnoreCase));
            }

            if (Duration != null)
            {
                result = result.ToList().FindAll(filterDuration => filterDuration.Duration == Duration);
            }

            if (PublicationYear != null)
            {
                result = result.ToList().FindAll(filterPublicationYear =>
                    filterPublicationYear.PublicationYear == PublicationYear);
            }

            return result.ToList();
        }

        public MusicRecordsData AddMusicRecord(MusicRecordsData newMusicRecord)
        {
            _recordContext.Add(newMusicRecord);
            _recordContext.SaveChanges();
            return newMusicRecord;
        }

        public MusicRecordsData DeleteMusicRecord(string title)
        {
            MusicRecordsData musicRecords = _recordContext.MusicRecords.Find(title);
            _recordContext.MusicRecords.Remove(musicRecords);
            return musicRecords;
        }

        public MusicRecordsData Update(string title, MusicRecordsData updates)
        {
            MusicRecordsData music = _recordContext.MusicRecords.Find(title);
            if (music == null) return null;
            music.Title = updates.Title;
            music.Artist = updates.Artist;
            music.Duration = updates.Duration;
            music.PublicationYear = updates.PublicationYear;
            _recordContext.SaveChanges();
            return music;
        }



    }
}
