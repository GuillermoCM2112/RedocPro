module.exports = function (Handlebars) {
    const regexMergeName = /(\[DEVELOP\]|\[FEATURE\]|\[HOTFIX\]|\[RELEASE\]|\[SPPP-\d{3}\]:?|\[BUG\]).*/gi;
    
    Handlebars.registerHelper('filterByRegex', function (array, options) {
        const matchedMessages = array.filter(({ message }) => message.match(regexMergeName));
        const map = new Map(matchedMessages.map(o => [o.message, o]));
        const unique = [...map.values()];
        return unique.map(u => `> 📦 ${u.message} [${u.shorthash ?? u.commit.shorthash}](${u.href}) by ${u.author}. <br>`.toUpperCase()).join('\n');
    });
}
