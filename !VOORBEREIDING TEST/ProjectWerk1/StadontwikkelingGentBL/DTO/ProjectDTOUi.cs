using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.DTO
{
    public class ProjectDTOUi
    {
        public ProjectDTOUi(int id, string titel, DateTime? startDatum, StatusProject status, bool isGroeneRuimteProject, bool isStadsOntwikkelingsProject, bool isInovatiefProject)
        {
            Id = id;
            Titel = titel;
            StartDatum = startDatum;
            Status = status;
            IsGroeneRuimteProject = isGroeneRuimteProject;
            IsStadsOntwikkelingsProject = isStadsOntwikkelingsProject;
            IsInovatiefProject = isInovatiefProject;
        }

        public int Id { get; set; }
        private string _titel;
        public string Titel
        {
            get => _titel;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _titel = value;
                else throw new ProjectException("Titel niet geldig!");
            }
        }
        private DateTime? _startDatum;
        public DateTime? StartDatum
        {
            get => _startDatum;
            set
            {
                _startDatum = value;
            }
        }
        public StatusProject Status { get; set; }

        public bool IsGroeneRuimteProject { get; set; }
        public bool IsStadsOntwikkelingsProject { get; set; }
        public bool IsInovatiefProject { get; set; }
    }
}