public class Main {

    public static void main(String[] args) {

        PaymentContext creditCard = new PaymentContext(new CreditCardPayment());
        creditCard.executePayment(2500);

        PaymentContext payPal = new PaymentContext(new PayPalPayment());
        payPal.executePayment(1800);
    }
}