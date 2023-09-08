import "../styles/Contact.css";

function Contact() {
  return (
    <section className="ContactPage">
      <form
        className="form"
        action="https://formsubmit.co/kangcohen@gmail.com"
        method="POST"
      >
        <div className="top">
          <input
            className="subject"
            id="subject"
            type="text"
            name="_subject"
            placeholder="subject"
            required
          />
          <input
            className="email"
            id="email"
            type="email"
            name="email"
            placeholder="your email (optional)"
          />
        </div>

        <textarea
          className="message"
          id="message"
          name="message"
          placeholder="your message"
          required
        />
        <button className="button" type="submit">
          Send
        </button>
      </form>
    </section>
  );
}

export default Contact;
