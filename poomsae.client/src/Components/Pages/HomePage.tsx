import React from 'react';
import { useNavigate } from 'react-router-dom';
import AppLayout from '../Fragments/Generic/AppLayout';
import { Button, Layout } from 'antd';

const HomePage: React.FC = () => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/login');
    };

    const poomsaeTitleStyle: React.CSSProperties = {
        fontFamily: 'Roboto, sans-serif',
        fontSize: '10rem',
        fontWeight: 'bold',
        background: 'linear-gradient(90deg, #c60c30, #003478)',
        animation: "scrollGradient 5s linear infinite",/* Rouge et bleu du taeguk */
        WebkitBackgroundClip: 'text',
        color: 'transparent',
        transition: 'transform 0.3s ease, text-shadow 0.3s ease',
    };

    const h2homepageStyle: React.CSSProperties = {
        fontWeight: '300'
    }

    return (
        <AppLayout>
            <Layout style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                {/* <section style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', height: '60vh' }}>
                    <h1 style={poomsaeTitleStyle}>
                        Poomsae
                    </h1>
                    <h2 style={h2homepageStyle}>Bienvenue sur le Réseau Social des Arts Martiaux</h2>
                    <Button className="btn" onClick={handleClick}>Commencer</Button>


                </section> */}

                <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100 p-6">
                    <h1 style={poomsaeTitleStyle}>
                        Poomsae
                    </h1>
                    {/* Slogan */}
                    <p className="text-lg text-gray-700 mt-4">
                        Le réseau social dédié aux passionnés d'arts martiaux.
                    </p>

                    {/* Section Features */}
                    <div className="mt-10 grid grid-cols-1 md:grid-cols-3 gap-6 max-w-4xl">
                        <FeatureCard
                            title="📈 Suivi de progression"
                            description="Suivez votre évolution, notez vos entraînements et améliorez-vous chaque jour."
                        />
                        <FeatureCard
                            title="👥 Communauté"
                            description="Échangez avec d'autres pratiquants, partagez vos techniques et vos expériences."
                        />
                        <FeatureCard
                            title="🎥 Apprentissage en vidéo"
                            description="Accédez à des démonstrations et perfectionnez vos mouvements avec des vidéos."
                        />
                    </div>

                    {/* Bouton d'inscription */}
                    <button className="mt-10 px-6 py-3 bg-red-600 hover:bg-red-700 text-white text-lg font-bold rounded-full shadow-lg transition">
                        Rejoindre la communauté
                    </button>
                </div>
            </Layout >
        </AppLayout >
    );
};
const FeatureCard: React.FC<{ title: string; description: string }> = ({
    title,
    description,
}) => {
    return (
        <div className="bg-white shadow-lg rounded-xl p-6 text-center hover:scale-105 transition-transform">
            <h3 className="text-xl font-bold text-gray-900">{title}</h3>
            <p className="text-gray-600 mt-2">{description}</p>
        </div>
    );
};
export default HomePage;
