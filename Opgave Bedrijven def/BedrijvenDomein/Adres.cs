using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenDomein
{
    public class Adres
    {


        public Adres(string woonplaats, string straatnaam, string huisnummer, int postcode)
        {
            List<string> errors = new();
            try { Woonplaats = woonplaats; } catch (BedrijfException ex) { errors.Add(ex.Message); }
            try { Straatnaam = straatnaam; } catch (BedrijfException ex) { errors.Add(ex.Message); }
            try { Huisnummer = huisnummer; }catch (BedrijfException ex) { errors.Add(ex.Message); }
            try { Postcode = postcode; } catch (BedrijfException ex) { errors.Add(ex.Message); }
            if (errors.Count > 0)
            {
                BedrijfException ex = new BedrijfException("Adres niet ok");
                ex.Errors = errors;
                throw ex;
            }
        }

        private string _woonplaats;
        public string Woonplaats {
            get { return _woonplaats; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) || value.Length >= 3)
                    _woonplaats = value;

                else throw new Exception("Woonplaats < 3");
            }
        }
        private string _straatnaam;
        public string Straatnaam {
            get { return _straatnaam; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _straatnaam = value;

                else throw new Exception("straatnaam niet ok");
            } }

        private string _huisnummer;
        public string Huisnummer {
            get { return _huisnummer; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && char.IsDigit(value[0]))
                    _huisnummer = value;
                else throw new Exception("huisnummer niet ok");
            } }
        private int _postcode;

        public int Postcode
        {
            get { return _postcode; }
            set
            {
                if (value >= 1000 && value <= 9999) _postcode = value;
                else throw new BedrijfException("Postcode niet ok");
            }
        }
        public override string ToString()
        {
            return $"{Woonplaats},{Straatnaam}, {Huisnummer}, {Postcode}";
        }
    }
}
