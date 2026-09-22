function findOccurrences(name) {
    name = "Priyanka Ajmera";
    var count = {};
    for (var char of name.toLowerCase()) {
        count[char] = (count[char] || 0) + 1;
    }
    for (var char in count) {
        if (char === " ")
            continue;
        console.log("ocuurance", char + " : " + count[char]);
    }
    // for (let i = 0; i < name.length; i++) {
    //   if (name[i] === ' ') continue;
    //   let occur = 1;
    //   for (let j = i+1; j < name.length; j++) {
    //     if (name[i] === name[j]) {
    //       occur++;
    //     }
    //   }
    //   console.log(name[i], occur);
    // }
}
function findIndex(name, char) {
    console.log("index of", char);
    console.log(name.indexOf(char));
}
// Finding first unique character in a string(char that does not repeat in string)
function uniqueChar(name) {
    name = "Rajesh Ajmera";
    var count = {};
    for (const char of name.toLowerCase()) {
        count[char] = (count[char] || 0) + 1;
    }
    for (const ch of name) {
        if (count[ch] === 1) {
            console.log("unique char", ch);
            return;
        }
    }
}
function groupAnagram(listName) {
    var _a;
    const anagramMap = new Map();
    for (let name of listName) {
        const sortedKey = name.split("").sort().join("");
        if (!anagramMap.has(sortedKey)) {
            anagramMap.set(sortedKey, []);
        }
        (_a = anagramMap.get(sortedKey)) === null || _a === void 0 ? void 0 : _a.push(name);
    }
    return Array.from(anagramMap.values());
}
function LengthOfLastWord() {
    let fullName = "Priyanka Ajmera";
    let i = 0;
    let lastWordLength = fullName.length - 1;
    while (i >= 0 && fullName[lastWordLength] !== " ") {
        i++;
        lastWordLength--;
    }
    console.log(i++);
}
function removeDuplicates(arr) {
    return [...new Set(arr)];
}
findOccurrences("Priyanka Ajmera");
findIndex("Priyanka Ajmera", "y");
uniqueChar("Rajesh Ajmera");
console.log(groupAnagram(["eat", "tea", "tan", "ate", "nat", "bat"]));
LengthOfLastWord();
console.log(removeDuplicates(["Priyanka", "Priyanka", "Rajesh"]));
