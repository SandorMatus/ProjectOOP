package cv5;

public class Test {
    public static void main(String[] args) {
        Zbozi[] poleZbozi = new Zbozi[4];
        poleZbozi[0] = new Potravina("Rohlik", 1.5, 1);
        poleZbozi[1] = new Naradi("Kleste", 278.0, 24);
        poleZbozi[2] = new Potravina("Chleba", 20.8, 6);
        poleZbozi[3] = new Potravina("Jablko", 51.0, 20);

        for (int i = 0; i < 4; i++) {
            if (poleZbozi[i] instanceof Potravina) {
                System.out
                        .println("Nazev Zbozi : " + poleZbozi[i].getNazevZbozi() + ", cena : " + poleZbozi[i].getCena()
                                + ", trvanlivost : " + ((Potravina) poleZbozi[i]).getTrvanlivost() + " "
                                + poleZbozi[i].getJednotka());
            } else {
                System.out
                        .println("Nazev Zbozi : " + poleZbozi[i].getNazevZbozi() + ", cena : " + poleZbozi[i].getCena()
                                + ", zarucni doba : " + ((Naradi) poleZbozi[i]).getZarucniDoba());
            }
        }
    }
}