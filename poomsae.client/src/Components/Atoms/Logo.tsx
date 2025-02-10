

interface LogoProps {
    name: string
    src: string
    size: "small" | "medium" | "big"
}

const Logo: React.FC<LogoProps> = ({ size, name, src }) => {

    const LogoStyle = {
        width: "100px",
        height: "65px",
        marginTop: "5px"

    }
    const smallStyle = {
        width: "30px",
        height: "20px",
        marginTop: "5px"
    }

    return (<> {size === "small" && <img style={smallStyle} src={src} alt={name} />}
        {size === "medium" && <img style={LogoStyle} src={src} alt={name} />}
        {size === "big" && <img style={LogoStyle} src={src} alt={name} />}
    </>
    )
}

export default Logo