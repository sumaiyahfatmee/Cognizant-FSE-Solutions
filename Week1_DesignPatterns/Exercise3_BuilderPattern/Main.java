public class Main {

    public static void main(String[] args) {

        Computer computer = new Computer.Builder()
                .setCpu("Intel Core i7")
                .setRam(16)
                .setStorage(512)
                .build();

        computer.display();
    }
}