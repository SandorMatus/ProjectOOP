package cv5;

public abstract class Zbozi {

    String nazevZbozi = "";
    double cenaBezDph = 0;
    static int DPH = 21;

    public Zbozi(String nazevZbozi, double cenaBezDph) {
        this.cenaBezDph = cenaBezDph;
        this.nazevZbozi = nazevZbozi;
    }

    public String getNazevZbozi() {
        return this.nazevZbozi;
    }

    public void setNazevZbozi(String nazevZbozi) {
        this.nazevZbozi = nazevZbozi;
    }

    public double getCena() {
        return this.cenaBezDph + this.cenaBezDph * this.DPH / 100;
    }

    public void setCenaBezDph(double cenaBezDph) {
        this.cenaBezDph = cenaBezDph;
    }

    public double getDph() {
        return DPH;
    }

    public static void setDph(double dph) {
        Zbozi.DPH = DPH;
    }

    public abstract String getJednotka();
}