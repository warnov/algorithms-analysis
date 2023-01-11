use std::io;

fn main() {
    let mut input = String::new();
    io::stdin().read_line(&mut input);
    let mut t: u16 = input.trim().parse().expect("");
    let mut result = String::new();
    while t > 0 {
        io::stdin().read_line(&mut input);
        input.clear();
        io::stdin().read_line(&mut input);
        let a = input.trim().as_bytes();
        let mut sum: u8 = a[0] - 0x30;
        a.iter().skip(1).for_each(|x| {
            if (sum == 0) {
                result.push('+');
            } else {
                result.push('-');
            }
            sum ^= x - 0x30;
        });
        println!("{}", result);
        result.clear();
        t -= 1;
    }
}