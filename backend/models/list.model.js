module.exports = (sequelize, Sequelize) => {
    const List = sequelize.define("list", {
        idL: {
            type: Sequelize.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },
        usernameL: {
            type: Sequelize.STRING
        },
        nombreRL: {
            type: Sequelize.STRING
        }
    });

    return List;
};