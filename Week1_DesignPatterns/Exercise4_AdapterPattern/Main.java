public class Main {

    public static void main(String[] args) {

        PaymentProcessor payPal = new PayPalAdapter(new PayPalGateway());
        PaymentProcessor stripe = new StripeAdapter(new StripeGateway());

        payPal.processPayment(1500);
        stripe.processPayment(2500);
    }
}