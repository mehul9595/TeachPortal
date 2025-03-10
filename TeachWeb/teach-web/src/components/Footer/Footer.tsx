import './Footer.css';

const Footer: React.FC = () => {
    return (
        <footer className="footer bg-primary text-white p-3">
            <p>&copy; {new Date().getFullYear()} Teach Portal. All rights reserved.</p>
            {/* additional nav footer area content */}
        </footer>
    );
};

export default Footer;