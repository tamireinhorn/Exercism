function count_nucleotides(strand::String)
	strand_copy = uppercase(strand) #Set the strand to upper
	alphabet = Set('A':'Z')
	nucleotides = Set(['A', 'C', 'T', 'G'])
	invalid_letters = setdiff(alphabet, nucleotides)
	strand_letters = Set(strand_copy)
	for letter in strand_letters
		if letter in invalid_letters
			return DomainError(letter)
		end

	end
	a_count = count("A", strand_copy)
	c_count = count("C",strand_copy)
	g_count = count("G",strand_copy)
	t_count = count("T",strand_copy)
	n_count =  Dict("A" => a_count, "C" => c_count, "G" => g_count, "T" => t_count)
	return n_count
end