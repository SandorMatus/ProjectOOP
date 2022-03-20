package cv5;

public class Potravina extends Zbozi {
    private int trvanlivost;

    public Potravina(String jmeno, double cena, int trvanlivost) {
        super(jmeno, cena);
        this.trvanlivost = trvanlivost;
    }

    public int getTrvanlivost() {
        return this.trvanlivost;
    }

    public void setTrvanlivost(int trvanlivost) {
        this.trvanlivost = trvanlivost;
    }

    public String getJednotka() {
        if (trvanlivost == 1)
            return "den";
        return "dni";
    }
}