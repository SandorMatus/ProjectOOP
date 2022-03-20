package cv5;

public class Naradi extends Zbozi {
    private int zarucniDoba;

    public Naradi(String jmeno, double cena, int zarucniDoba) {
        super(jmeno, cena);
        this.zarucniDoba = zarucniDoba;
    }

    public int getZarucniDoba() {
        return this.zarucniDoba;
    }

    public void setZarucniDoba(int zarucniDoba) {
        this.zarucniDoba = zarucniDoba;
    }

    public String getJednotka() {
        if (zarucniDoba == 1)
            return "mesiac";
        return "mesiacov";
    }
}